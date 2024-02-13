import { Todos } from './../../models/Todos';
import { Component, OnInit } from '@angular/core';
import { TodoService } from '../../services/todo.service';
import { NgFor } from '@angular/common';


@Component({
  selector: 'app-home',
  standalone: true,
  providers: [TodoService],
  imports: [NgFor],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{

  todos: Todos[] = [];
  todoCurrent: Todos[] = [];

  constructor(private todoService: TodoService){}

  ngOnInit(): void {
      this.todoService.GetTodos().subscribe(data => {
        const todoListData = data;
        todoListData.map((item) => {
          console.log(item)
        })

        this.todos = todoListData;
        this.todoCurrent = todoListData;

      });
      
  }
}
