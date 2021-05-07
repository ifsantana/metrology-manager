import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { ActuallPoint } from '../models/actual.point';
import { ActualPointsCollection } from '../models/actual.points.collection';
import { ResponseBase } from '../models/response.base';

@Injectable()
export class ActualPointsService {
  private _baseUri: string = `${environment.backEndBaseUrl}/points/actuals`;
  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<ResponseBase<ActualPointsCollection>>(this._baseUri).pipe();
  }

  getByNominalPointId(id: string) {
    return this.http.get<ResponseBase<ActualPointsCollection>>(`${environment.backEndBaseUrl}/points/nominals/${id}/actuals`).pipe();
  }

  create(actualPoint: ActuallPoint) {
    return this.http.post(`${environment.backEndBaseUrl}/points/nominals/${actualPoint.nominalPointId}/actuals`, actualPoint);
  }

  update(actualPoint: ActuallPoint) {
    return this.http.put(`${this._baseUri}/${actualPoint.id}`, actualPoint);
  }

  updatePartially(actualPoint: ActuallPoint) {
    return this.http.patch(`${this._baseUri}/${actualPoint.id}`, actualPoint);
  }

  delete(user: string, id: number) {

    return this.http.request('DELETE', `${this._baseUri}`, { headers: new HttpHeaders({ 'Content-Type': 'application/json' }), body: { executionUser: `${user}`, id: `${id}` } });
  }
}
