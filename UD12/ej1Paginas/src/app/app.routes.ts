import { Routes } from '@angular/router';
import { TablaPersonas } from './components/tabla-personas/tabla-personas';
import { Formulario } from './components/formulario/formulario';
import { Listilla } from './components/listilla/listilla';

export const routes: Routes = [
    {path: '', component: TablaPersonas},
    {path: 'listilla', component: Listilla},
    {path: 'formulario', component: Formulario}
];
