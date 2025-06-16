import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class MovimientosapiService {
  private readonly baseUrlCuenta = 'http://localhost:2646/api/Cuenta';
  private readonly baseUrlTransaccion = 'http://localhost:2646/api/Transaccion';

  constructor(private http: HttpClient) { }

  postCuenta(data: any) {
    return this.http.get(this.baseUrlCuenta);
  }

  postTransaccion(data: any) {
    return this.http.post(this.baseUrlTransaccion, data);
  }
}
