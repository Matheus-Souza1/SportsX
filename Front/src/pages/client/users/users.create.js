import React from 'react';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import CssBaseline from '@mui/material/CssBaseline';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import schema from '../../../schema/schema';
import Paper from '@mui/material/Paper';
import { useHistory } from 'react-router-dom'
import { Formik, Field, Form, ErrorMessage, FieldArray } from 'formik';
import MaskedInput from 'react-text-mask';
import './users.css'

import Api from '../../../services/api';

import Container from '@mui/material/Container';
import Grid from '@mui/material/Grid';
import MenuAdmin from '../../../components/menu.admin';
import Footer from '../../../components/footer-admin'


const mdTheme = createTheme();

function DashboardContent() {


    const [open, setOpen] = React.useState(true);
    const toggleDrawer = () => {
        setOpen(!open);
    };

    function validateName(value) {
        let error;
        if (!value) {
            error = 'Campo é obrigatorio!'
        } else if (value.length > 100) {
            error = 'Campo não deve ultrapassar 100 caracteres!'
        }
        return error;
    }
    async function onSubmit(values, actions) {
        const response = await Api.post('/client', values);
        if (response.status === 201) {
            window.location.href = '/users'
        } else {
            alert('Erro ao cadastrar o usuário!');
        }
    }


    const phoneNumberMask = [
        "(",
        /[1-9]/,
        /\d/,
        ")",
        " ",
        /\d/,
        /\d/,
        /\d/,
        /\d/,
        /\d/,
        "-",
        /\d/,
        /\d/,
        /\d/,
        /\d/
    ];
    const cepMask = [
        /[1-9]/,
        /\d/,
        "-",
        /\d/,
        /\d/,
        /\d/,
        "-",
        /\d/,
        /\d/,
        /\d/
    ];

    const history = useHistory();

    const handlerRedirectHome = () => {
        return history.push('/users');
    };

    return (
        <ThemeProvider theme={mdTheme}>
            <Box sx={{ display: 'flex' }}>
                <CssBaseline />
                <MenuAdmin title={'USUARIOS'} />
                <Box
                    component="main"
                    sx={{
                        backgroundColor: (theme) =>
                            theme.palette.mode === 'light'
                                ? theme.palette.grey[100]
                                : theme.palette.grey[900],
                        flexGrow: 1,
                        height: '100vh',
                        overflow: 'auto',
                    }}
                >
                    <Toolbar />
                    <Container maxWidth="lg" sx={{ mt: 4, mb: 2 }}>
                        <Grid container spacing={{ xs: 2, md: 3 }} columns={{ xs: 2, sm: 8, md: 12 }}>
                            <Grid item xs={20} sm={7} >
                                <Paper>
                                    <Formik
                                        validationSchema={schema}
                                        onSubmit={onSubmit}
                                        initialValues={{
                                            name: null,
                                            corporateName: null,
                                            typeClient: 0,
                                            document: '',
                                            cep: '',
                                            classification: 0,
                                            email: '',
                                            phones: [
                                                { number: '' }]
                                        }}
                                        render={({ values, handleSubmit, setFieldValue, isValid }) => (
                                            <Form>

                                                <h1> Formulario </h1>
                                                <div className="client-form">
                                                    <label >Tipo de Cliente</label>
                                                    < Field name="typeClient" as="select" className="Field"
                                                        onChange={(e) => {
                                                            setFieldValue(
                                                                "typeClient",
                                                                parseInt(e.target.value)
                                                            );
                                                        }}>
                                                        <option defaultValue>Selecione a forma de cadastro</option>
                                                        <option value={1}>FISICO</option>
                                                        <option value={2}>JURIDICO</option>
                                                    </Field>
                                                    <ErrorMessage name="typeClient" render={msg => <div className="error">{msg}</div>} />
                                                </div>

                                                {
                                                    values["typeClient"] === 1 ? <div className="client-form">
                                                        <label>Nome do Cliente</label>
                                                        <Field name="name" type="text" className="Field" validate={validateName} />
                                                        <ErrorMessage name="name" render={msg => <div className="error">{msg}</div>} />
                                                    </div>
                                                        :
                                                        <div className="client-form">
                                                            <label>Razão Social</label>
                                                            <Field name="corporateName" type="text" className="Field" validate={validateName} />
                                                            <ErrorMessage name="corporateName" render={msg => <div className="error">{msg}</div>} />
                                                        </div>
                                                }

                                                <div className="client-form">
                                                    <label >Documento</label>
                                                    <Field name="document" type="text" className="Field" />
                                                    <ErrorMessage name="document" render={msg => <div className="error">{msg}</div>} />
                                                </div>

                                                <div className="client-form">
                                                    <label >CEP</label>
                                                    <Field
                                                        name="cep"
                                                        render={({ field }) => (
                                                            <MaskedInput
                                                                {...field}
                                                                mask={cepMask}
                                                                id="cep"
                                                                type="text"
                                                                component="div"
                                                                className="Field"
                                                            />
                                                        )}
                                                    />
                                                    <ErrorMessage name="cep" render={msg => <div className="error">{msg}</div>} />
                                                </div>

                                                <div className="client-form">
                                                    <label >Email</label>
                                                    <Field name="email" type="email" className="Field" />
                                                    <ErrorMessage name="email" render={msg => <div className="error">{msg}</div>} />
                                                </div>

                                                <div className="client-form">
                                                    <label >Classificação</label>
                                                    < Field name="classification" as="select" className="Field" onChange={(e) => {
                                                        setFieldValue(
                                                            "classification",
                                                            parseInt(e.target.value)
                                                        );
                                                    }}  >
                                                        <option defaultValue>Selecione uma classificação</option>
                                                        <option value={1}>Ativo</option>
                                                        <option value={2}>Inativo</option>
                                                        <option value={3}>Preferencial</option>
                                                    </Field>
                                                    <ErrorMessage name="classification" render={msg => <div className="error">{msg}</div>} />
                                                </div>

                                                <div className="client-form">
                                                    <FieldArray name="phones" type="text" className="FieldArray">
                                                        {({ insert, remove, push }) => (
                                                            <div>
                                                                {values.phones.length > 0 &&
                                                                    values.phones.map((phones, index) => {
                                                                        return (
                                                                            <div key={index}>
                                                                                <div>
                                                                                    <label htmlFor={`phones.${index}.number`}>Telefone {index + 1}</label>
                                                                                    <Field
                                                                                        name={`phones.${index}.number`}
                                                                                        className="Array"
                                                                                        render={({ field }) => (
                                                                                            <MaskedInput
                                                                                                {...field}
                                                                                                mask={phoneNumberMask}
                                                                                                id="phones"
                                                                                                placeholder="digite seu numero"
                                                                                                type="text"
                                                                                                component="div"
                                                                                                className="Field"

                                                                                            />
                                                                                        )}
                                                                                    />
                                                                                    <button
                                                                                        type="button"
                                                                                        className="exclude"
                                                                                        onClick={() => remove(index)}
                                                                                    >
                                                                                        X
                                                                                    </button>

                                                                                </div>
                                                                            </div>
                                                                        );
                                                                    })}
                                                                <button
                                                                    type="button"
                                                                    className="secondary"
                                                                    onClick={() => push({ number: '' })}
                                                                >
                                                                    Adicionar Telefone
                                                                </button>
                                                            </div>
                                                        )}
                                                    </FieldArray>
                                                    <ErrorMessage name="number" render={msg => <div className="error">{msg}</div>} />
                                                </div>
                                                <button type="submit" className="sucess" disabled={!isValid} onSubmit={handleSubmit} >Salvar</button>
                                                <input className="btn-salvar" type="button" value="Voltar" onClick={() => handlerRedirectHome()} />
                                            </Form>
                                        )}
                                    />
                                </Paper>
                            </Grid>
                        </Grid>
                        <Footer sx={{ pt: 4 }} />
                    </Container>
                </Box>
            </Box>
        </ThemeProvider>
    );
}

export default function UsersCreate() {
    return <DashboardContent />;
}