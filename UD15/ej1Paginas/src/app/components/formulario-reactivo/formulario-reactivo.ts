import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-formulario-reactivo',
  imports: [RouterLink, FormsModule],
  templateUrl: './formulario-reactivo.html',
  styleUrl: './formulario-reactivo.css',
})
export class FormularioReactivo {
  
  persona = {
    id: '',
    nombre: ''
  }

  public saludar(): void{
    const valid: number = this.checkData();
    if (this.persona.id !='' && this.persona.nombre != '' && valid == 0){
      alert(`Hola: ${this.persona.nombre}!`)
    } else if(valid == 1){
      alert("Fallo en el nombre, no puede contener carácteres especiales")
    } else if(valid == 2){
      alert("Fallo en el id, solo puede contener números")
    }
  }

  private checkData() : number{
    let valid : number = 0
    const patronNombre = /^[a-z0-9 ]+$/i;
    const patronId = /^[0-9]+$/;

    if (!patronNombre.test(this.persona.nombre)){
      valid = 1
    }
    
    if (patronId.test(this.persona.id)){
      const numero : number = Number(this.persona.id)
      if(numero < 0){
        valid = 2
      }
    } else{
      valid = 2
    }

    return valid

  }


}
