import { Routes } from '@angular/router';
import { TablaPersonas } from './components/tabla-personas/tabla-personas';
import { Formulario } from './components/formulario/formulario';
import { Listilla } from './components/listilla/listilla';
import { FormularioReactivo } from './components/formulario-reactivo/formulario-reactivo';
import { FormularioReactivoBien } from './components/formulario-reactivo-bien/formulario-reactivo-bien';

export const routes: Routes = [
    {path: '', component: TablaPersonas},
    {path: 'listilla', component: Listilla},
    {path: 'formulario', component: Formulario},
    {path: 'formularioReactivo', component: FormularioReactivo},
    {path: 'formularioReactivoBien', component: FormularioReactivoBien}
];
