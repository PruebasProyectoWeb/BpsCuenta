import { Routes } from '@angular/router';
import { CuentaComponent } from './cuenta/cuenta.component';

export const routes: Routes = [
    { path: 'cuenta', component: CuentaComponent },
    { path: '', redirectTo: '/cuenta', pathMatch: 'full' }
];
