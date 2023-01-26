import { Component, OnInit } from '@angular/core';
import { TaskService } from '../../services/task.service';
import { Task } from '../../Task';


@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {
tasks!: any;

  constructor(private taskSevice: TaskService) { }

  ngOnInit(): void {
     this.taskSevice.getTasks().subscribe((tasks) => this.
     tasks = tasks);
  }

  deleteTask(task: Task){
    // this.taskSevice
    //  .deleteTask(task)
    //  .subscribe(
    //    () => (this.tasks = this.tasks.filter(t => t.id !== task.id)));
  }

  toggleReminder(task:Task){
    task.reminder = !task.reminder;  
    this.taskSevice.updateTaskReminder(task).subscribe();
    
  }

  addTask(task: Task){
    // this.taskSevice.addTask(task).subscribe((task) => this.tasks.push(task));
  }
  
}
