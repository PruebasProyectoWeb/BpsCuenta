import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { MovimientosapiService } from '../services/movimientosapi.service';
import { CommonModule } from '@angular/common';
//import { HttpClientModule } from '@angular/common/http';



@Component({
  selector: 'app-cuenta',
  imports: [ReactiveFormsModule, CommonModule],
  standalone: true,
  templateUrl: './cuenta.component.html',
  styleUrl: './cuenta.component.css'
})
export class CuentaComponent {
  cuentaForm: FormGroup;

  constructor(private fb: FormBuilder, private movimientosapiService: MovimientosapiService) {
    this.cuentaForm = this.fb.group({
      numeroCuenta: ['', [Validators.required]],
      nombreTitular: ['', [Validators.required]],
      saldo: [0, [Validators.required, Validators.min(0)]]
    });
  }


  onSubmit(): void {
    if (this.cuentaForm.valid) {
      this.movimientosapiService.postCuenta(this.cuentaForm.value).subscribe(
        response => {
          console.log('Cuenta creada exitosamente', response);
        },
        error => {
          console.error('Error al crear la cuenta', error);
        }
      );
    }
  }






}
