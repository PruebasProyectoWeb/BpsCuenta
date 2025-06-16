import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { CuentaComponent } from './cuenta/cuenta.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  standalone: true,
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'movimientosFront';
  constructor(private router: Router) {
    this.router.navigate(['/cuenta']);
  }
}
