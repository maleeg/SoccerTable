import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TeamsService {
url = "http://localhost:5000/SoccerTable"
  constructor(private http:HttpClient) { }
  getTeams(){
    return this.http.get(this.url);
  }
}
