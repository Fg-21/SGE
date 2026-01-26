import { Component } from '@angular/core';
import {MobxAngularModule} from 'mobx-angular'
@Component({
  selector: 'app-lista-personas',
  standalone : true,
  imports: [MobxAngularModule],
  templateUrl: './lista-personas.html',
  styleUrl: './lista-personas.css',
})
export class ListaPersonas {

}
