import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TablaPersonas } from './components/tabla-personas/tabla-personas';
import { Formulario } from './components/formulario/formulario';
import { Listilla } from './components/listilla/listilla';
import { FormularioReactivo } from './components/formulario-reactivo/formulario-reactivo';


@Component({
  selector: 'app-root',
  imports: [RouterOutlet, TablaPersonas, Formulario, Listilla, FormularioReactivo],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('ej1Paginas');
}

