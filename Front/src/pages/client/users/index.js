import React, { useState, useEffect } from 'react';
import { useHistory } from 'react-router-dom'
import { createTheme, ThemeProvider } from '@mui/material/styles';
import CssBaseline from '@mui/material/CssBaseline';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Paper from '@mui/material/Paper';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell, { tableCellClasses } from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import ButtonGroup from '@mui/material/ButtonGroup';
import Button from '@mui/material/Button';
import Chip from '@mui/material/Chip';
import { styled } from '@mui/material/styles';
import DeleteIcon from '@mui/icons-material/Delete';
import PencilIcon from '@mui/icons-material/Create';

import Api from '../../../services/api';

import Container from '@mui/material/Container';
import Grid from '@mui/material/Grid';
import MenuAdmin from '../../../components/menu.admin';
import Footer from '../../../components/footer-admin'
import { getClassification, getLabel } from '../../../functions/static.classification';


const StyledTableCell = styled(TableCell)(({ theme }) => ({
  [`&.${tableCellClasses.head}`]: {
    backgroundColor: theme.palette.common.black,
    color: theme.palette.common.white,
  },
  [`&.${tableCellClasses.body}`]: {
    fontSize: 14,
  },
}));

const StyledTableRow = styled(TableRow)(({ theme }) => ({
  '&:nth-of-type(odd)': {
    backgroundColor: theme.palette.action.hover,
  },
  // hide last border
  '&:last-child td, &:last-child th': {
    border: 0,
  },
}));


const mdTheme = createTheme();

function DashboardContent() {

  const [clients, setClients] = useState([]);

  useEffect(() => {
    async function loadClients() {
      const response = await Api.get("/client");
      setClients(response.data);
    }
    loadClients();
  }, []);

  async function handleDelete(id) {
    if (window.confirm("Deseja realmente excluir este usuário?")) {
      var result = await Api.delete('/client/' + id);
      if (result.status === 204) {
        window.location.href = '/users';
      } else {
        alert('Ocorreu um erro. Por favor, tente novamente!');
      }
    }
  }

  const [open, setOpen] = React.useState(true);
  const toggleDrawer = () => {
    setOpen(!open);
  };

  const history = useHistory();

  const handlerRedirectForm = () => {
    return history.push('/users/add');
  };

  return (

    <ThemeProvider theme={mdTheme}>
      <Box sx={{ display: 'flex' }}>
        <CssBaseline />
        <MenuAdmin title={'Listagem'} />
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
          <Container maxWidth="lg" sx={{ mt: 4, mb: 4 }}>
            <Grid container spacing={3}>
              <Grid item sm={22}>
                <Paper>
                  <h2>Painel de Usuarios</h2>
                  <Grid container spacing={3}>
                    <Grid item sm={22}>
                      <Button color="info" variant="contained" onClick={handlerRedirectForm}>NOVO + </Button>
                      <TableContainer component={Paper}>
                        <Table sx={{ minWidth: 650 }} aria-label="simple table">
                          <TableHead>
                            <TableRow>
                              <StyledTableCell >Tipo de Cliente</StyledTableCell>
                              <StyledTableCell align="center">Cliente</StyledTableCell>
                              <StyledTableCell align="center">Documento</StyledTableCell>
                              <StyledTableCell align="center">Cep</StyledTableCell>
                              <StyledTableCell align="center">Email</StyledTableCell>
                              <StyledTableCell align="center">Classificação</StyledTableCell>
                              <StyledTableCell align="center">Telefones</StyledTableCell>
                              <StyledTableCell align="center">Opções</StyledTableCell>
                            </TableRow>
                          </TableHead>
                          <TableBody>
                            {clients.map((row) => (
                              <StyledTableRow
                                key={row.id}
                                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                              >
                                <StyledTableCell>{row.typeClient === 1 ? <Chip label="Fisico" variant="outlined" color="info" /> : <Chip label="Juridico" variant="outlined" color="success" />} </StyledTableCell>
                                <StyledTableCell align="center">{row.typeClient === 1 ? row.name : row.corporateName}</StyledTableCell>
                                <StyledTableCell align="center">{row.document}</StyledTableCell>
                                <StyledTableCell align="center">{row.cep}</StyledTableCell>
                                <StyledTableCell align="center">{row.email}</StyledTableCell>
                                <StyledTableCell align="center"><Chip label={getClassification(row.classification)} variant="outlined" color={getLabel(row.classification)} /></StyledTableCell>
                                <StyledTableCell align="center">{row.phones.map((phones) => (<p> {phones.number} </p>))}</StyledTableCell>
                                <StyledTableCell align="center">
                                  <ButtonGroup disableElevation>
                                    <Button color="warning" variant="contained" startIcon={<PencilIcon />} href={'/client/' + row.id}></Button>
                                    <Button color="error" variant="contained" startIcon={<DeleteIcon />} onClick={() => handleDelete(row.id)}></Button>
                                  </ButtonGroup>
                                </StyledTableCell>
                              </StyledTableRow>
                            ))}
                          </TableBody>
                        </Table>
                      </TableContainer>
                    </Grid>
                  </Grid>
                </Paper>
              </Grid>
            </Grid>
            <Footer sx={{ pt: 4 }} />
          </Container>
        </Box>
      </Box >
    </ThemeProvider >
  );
}

export default function Dashboard() {
  return <DashboardContent />;
}