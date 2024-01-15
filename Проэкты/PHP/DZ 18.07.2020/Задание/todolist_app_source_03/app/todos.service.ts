import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

export class Task {
  id: number;
  title: string;
  completed: boolean;
  date?: any;
}

@Injectable({
  providedIn: 'root'
})
export class TodosService {
  
  tasks: Task[] = [];

  constructor(public http: HttpClient) { }

  fetchTasks(): Observable<Task[]> {
    return this.http.get<Task[]>('https://jsonplaceholder.typicode.com/todos?_limit=12')
      .pipe(map(todos => this.tasks = todos));
  }

  onToggle(id: number): void {
    const index = this.tasks.findIndex(t => t.id === id);
    this.tasks[index].completed = !this.tasks[index].completed;
  }

  removeTask(id: number): void {
    this.tasks = this.tasks.filter(t => t.id !== id);
  }

  addTask(task: Task) {
    this.tasks.push(task);
  }
}
