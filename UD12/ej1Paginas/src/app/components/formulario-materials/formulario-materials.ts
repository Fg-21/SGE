import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-formulario-materials',
  imports: [MatFormFieldModule, MatInputModule, MatIconModule, MatButtonModule, ReactiveFormsModule],
  templateUrl: './formulario-materials.html',
  styleUrl: './formulario-materials.css',
})
export class FormularioMaterials implements OnInit {
  formulario !: FormGroup
  
  
  ngOnInit(): void {
    this.formulario = new FormGroup({
      nombre: new FormControl('', [Validators.required]),
      apellidos: new FormControl('', [])
    });
  }
  
  saluda(): void{
    alert("Hola "+ this.formulario.controls['nombre'].value)
  }
  
}
