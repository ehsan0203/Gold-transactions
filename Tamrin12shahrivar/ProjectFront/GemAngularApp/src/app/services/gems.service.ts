import { Injectable } from '@angular/core';
import { Gem } from '../models/gem';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GemsService {
  gems: Gem[]=[]
  constructor(private httpClient: HttpClient) {
  }
  public getgems(): Observable<Gem[]> {
    return this.httpClient.get<Gem[]>("https://localhost:7132/api/Gem")
  }
}
