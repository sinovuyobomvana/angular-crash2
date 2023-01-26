import { Injectable } from '@angular/core';
import { Observable} from 'rxjs';
import { Task } from '../Task';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOtions  = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};

@Injectable({
  providedIn: 'root'
})
export class TaskService {
 private apiUrl = 'https://localhost:7216/api/Task';

  constructor(private Http:HttpClient) { }

  getTasks() : Observable<Task> {
    return this.Http.get<Task>(this.apiUrl);
  }

  deleteTask(task:Task): Observable<Task>{
    const url = `${this.apiUrl}/${task.id}`;
    return this.Http.delete<Task>(url);
  }

  updateTaskReminder(task:Task): Observable<Task>{
    const url = `${this.apiUrl}/${task.id}`;
    return this.Http.put<Task>(url, task, httpOtions);
  }

  addTask(task:Task): Observable<Task>{
    return this.Http.post<Task>(this.apiUrl, task, httpOtions);
  }
}
