import { Component, OnInit } from '@angular/core';
import { Task, TodosService } from '../todos.service';

@Component({
  selector: 'app-todo-form',
  templateUrl: './todo-form.component.html',
  styleUrls: ['./todo-form.component.css']
})
export class TodoFormComponent implements OnInit {

  title: string = '';

  constructor(public todosService: TodosService) { }

  ngOnInit(): void {
  }

  addTask() {
    const task: Task = {
      title: this.title,
      id: Date.now(),
      completed: false,
      date: new Date().toLocaleString()
    };
    this.todosService.addTask(task);
    this.title = '';
  }

}
