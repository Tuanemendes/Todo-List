import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Todos } from '../models/Todos';


@Injectable({
  providedIn: 'root'
})
export class TodoService {

  private apiUrl =`${environment.ApiUrl}/TodoList`

  constructor(private http:HttpClient) { }

  GetTodos():Observable<Todos[]>{
    return this.http.get<Todos[]>(this.apiUrl);
  }

}
