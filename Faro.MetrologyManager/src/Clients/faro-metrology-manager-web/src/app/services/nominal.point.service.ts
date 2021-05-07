import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { NominalPoint } from '../models/nominal.point';
import { NominalPointsCollection } from '../models/nominal.points.collection';
import { ResponseBase } from '../models/response.base';

@Injectable()
export class NominalPointsService {
  private _baseUri: string = `${environment.backEndBaseUrl}/points/nominals`;
  constructor(private http: HttpClient) { }
  
  getAll() {
    return this.http.get<ResponseBase<NominalPointsCollection>>(this._baseUri).pipe();
  }

  create(nominalPoint: NominalPoint) {
    return this.http.post(this._baseUri, nominalPoint);
  }

  update(nominalPoint: NominalPoint) {
    return this.http.put(`${this._baseUri}/${nominalPoint.id}`, nominalPoint);
  }

  updatePartially(nominalPoint: NominalPoint) {
    return this.http.patch(`${this._baseUri}/${nominalPoint.id}`, nominalPoint);
  }

  delete(id: number) {
    return this.http.delete(`${this._baseUri}/${id}`);
  }
}
