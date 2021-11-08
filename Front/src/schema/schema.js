import * as Yup from 'yup';

export default Yup.object().shape({
    document: Yup.string().required("Numero do documento é obrigatorio!"),
    typeClient: Yup.number().required("Escolha uma forma de cadastro!"),
    cep: Yup.string().required("CEP é obrigatorio!"),
    classification: Yup.number().required("Classsificação é obrigatorio!"),
    email: Yup.string().email("Deve ser um e-mail válido!").required("Email é obrigatorio!"),
    telphone: Yup.object().shape({
        number: Yup.array().of(Yup.object().shape({ number: Yup.number().min(20).max(20) }))
    })
})