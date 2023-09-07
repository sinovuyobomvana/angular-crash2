import { Component, OnInit } from '@angular/core';
import { TaskService } from '../../services/task.service';
import { Task } from '../../models/Task';
import { Router } from '@angular/router';


@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {
tasks: Task [] = [];

  constructor(private taskSevice: TaskService, private route:Router) { }

  ngOnInit(): void {
      this.getTasks();
  }

  getTasks(){
    this.taskSevice.getTasks().subscribe({
      next: tasks => this.tasks = tasks
    })
  }

  deleteTask(task: Task){
    this.taskSevice
     .deleteTask(task)
     .subscribe(
       () => (this.tasks = this.tasks.filter(t => t.id !== task.id)));
  }

  toggleReminder(task:Task){
    task.Reminder = !task.Reminder;  
    this.taskSevice.updateTaskReminder(task).subscribe();
    
  }

  addTask(task: Task){
    this.taskSevice.addTask(task).subscribe({
      next:(success)=>{
        
        //this.route.navigate([''])
        
        window.location.href = "/";
      },

    })
    
  }
  
}
