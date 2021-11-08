using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SportsXs.API.InputModel;
using SportsXs.API.ViewModels;
using SportsXs.Domain.Entities;
using SportsXs.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsXs.API.Controllers
{
    // api/Client
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAllHeaders")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _repository;
        private readonly IPhonesRepository _phonesRepository;
        private readonly IMapper _mapper;

        public ClientController(IClientRepository repository, IPhonesRepository phonesRepository, IMapper mapper)
        {
            _repository = repository;
            _phonesRepository = phonesRepository;
            _mapper = mapper;
        }

        //GET api/Client
        /// <summary>
        /// Retorna todos os clientes
        /// </summary>
        /// <returns>Objeto de detalhes dos clientes</returns>
        /// <response code="404">Clientes não encontrados</response>
        /// <response code="200">Clientes encontrados</response>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _repository.GetAllAsync();
            var clientsViewModel = _mapper.Map<List<ClientViewModel>>(clients);

            return Ok(clientsViewModel);
        }

        //GET api/Client/3c50390e-2ddc-4de6-9a6b-0f5c3c7aecb0
        /// <summary>
        /// Retornar detalhes de um Cliente
        /// </summary>
        /// <param name="id">Identificador do Cliente</param>
        /// <returns>Objeto de detalhes do Cliente</returns>
        /// <response code="404">Cliente não encontrado</response>
        /// <response code="200">Cliente encontrado</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var client = await _repository.GetByIdAsync(id);

            if(client == null)
            {
                return NotFound();
            }

            var clientViewModel = _mapper.Map<ClientViewModel>(client);

            return Ok(clientViewModel);
        }

        //POST api/Client
        /// <summary>
        /// Cadastrar um Cliente
        /// </summary>
        /// <remarks>
        /// {
        /// "name": "string",
        /// "corporateName": "string",
        /// "document": "string",
        /// "email": "string",
        /// "cep": "string",
        /// "typeClient": 1,
        /// "classification": 1,
        /// "phones": [
        ///  {
        ///    "number": "string"
        ///  }
        /// ]
        /// }
        /// </remarks>
        /// <param name="model">Objeto com dados de cadastro do Cliente</param>
        /// <returns>Objeto recém-criado.</returns>
        /// <response code="201">Objeto criado com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddClientInputModel model)
        {
            var client = _mapper.Map<Client>(model);
            await _repository.AddAsync(client);

            return CreatedAtAction(nameof(GetById), new { Id = client.Id }, model);
        }

        //PUT api/Client/3c50390e-2ddc-4de6-9a6b-0f5c3c7aecb0
        /// <summary>
        /// Atualizar dados do Cliente
        /// </summary>
        /// <remarks>
        /// {
        /// "name": "string",
        /// "corporateName": "string",
        /// "document": "string",
        /// "email": "string",
        /// "cep": "string",
        /// "typeClient": 1,
        /// "classification": 1,
        /// "phones": [
        ///  {
        ///    "number": "string"
        ///  }
        /// ]
        /// }
        /// </remarks>
        /// <param name="id">Identificador do Cliente</param>
        /// <param name="model">Objeto com dados de atualização do Cliente</param>
        /// <returns>Objeto Atualizado</returns>
        /// <response code="204">Objeto atualizado com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateClientInputModel model)
        {
            var client = await _repository.GetByIdAsync(id);

            if(client == null)
            {
                return NotFound();
            }

            var newPhones = new List<Phones>();

            foreach (var item in model.Phones)
            {
                var phone = client.Phones.Find(x => x.Id == item.Id);

                if (item.Id.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    phone = new Phones(item.Number, client.Id);
                    await _phonesRepository.Add(phone);
                    newPhones.Add(phone);
                }        
               else
                {          
                    phone.Update(item.Number);
                    newPhones.Add(phone);
                }           
            }

            client.UpdatePhones(newPhones);

            client.Update( model.Name, model.CorporateName, model.Document, model.Email,model.Cep , model.Classification, model.TypeClient, client.Phones);
           
            await _repository.UpdateAsync(client);

            return NoContent();
        }

        //DELETE api/Client/3c50390e-2ddc-4de6-9a6b-0f5c3c7aecb0
        /// <summary>
        /// Deletar um Cliente
        /// </summary>
        /// <param name="id">Identificador do Cliente</param>
        /// <returns>Usuario deletado</returns>
        /// <response code="204">Objeto deletado com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var client = await _repository.GetByIdAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            await _repository.Delete(id);

            return NoContent();
        }
    }
}
