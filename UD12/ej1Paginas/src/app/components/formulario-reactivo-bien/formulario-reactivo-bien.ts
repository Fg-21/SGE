import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-formulario-reactivo-bien',
  imports: [ReactiveFormsModule],
  templateUrl: './formulario-reactivo-bien.html',
  styleUrl: './formulario-reactivo-bien.css',
})
export class FormularioReactivoBien implements OnInit {
  formulario!: FormGroup

  constructor(){

  }

  ngOnInit(): void {
    this.formulario = new FormGroup({
      nombre: new FormControl('', [Validators.required]),
      apellidos: new FormControl('', [])
    });
  }

  saluda(): void{
    if (this.formulario.valid){
      alert("Hola " + this.formulario.controls['nombre'].value + " " + this.formulario.controls['apellidos'].value);
    }
  }
}
