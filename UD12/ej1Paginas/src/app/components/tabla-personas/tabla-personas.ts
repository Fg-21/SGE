import { Component } from '@angular/core';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatProgressSpinner } from '@angular/material/progress-spinner';
import { MatRadioButton } from '@angular/material/radio';
import { MatSliderModule } from '@angular/material/slider';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-tabla-personas',
  imports: [RouterLink, MatProgressSpinner, MatRadioButton, MatSliderModule, MatExpansionModule],
  templateUrl: './tabla-personas.html',
  styleUrl: './tabla-personas.css',
})
export class TablaPersonas {

}
