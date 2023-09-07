import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Task } from '../../models/Task';
import { UiService } from '../../services/ui.service';
import { Subscription } from 'rxjs';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.css']
})
export class AddTaskComponent implements OnInit {
  @Output() onAddTask: EventEmitter<Task> = new EventEmitter();
  
  name!: string;
  dayAndTime!: string;
  reminder: boolean = false;
  showAddTask!: boolean;
  subscription!: Subscription;

  constructor(private uiService: UiService, private formBuilder:FormBuilder) {
    this.subscription = this.uiService
    .onToggle()
    .subscribe(value => this.showAddTask = value);
   }

    ngOnInit(): void {
  }

  onSubmit (){
    if(!this.name){
      alert('Please add task');
      return;
    }

    const newTask = {
      Name: this.name,
      DayAndTime: this.dayAndTime,
      Reminder: this.reminder
    }

    this.onAddTask.emit(newTask);

    this.name = '';
    this.dayAndTime = '';
    this.reminder = false;
  }

  profileForm = this.formBuilder.group({
    firstName: ['', [Validators.required]],
    lastName: ['', [Validators.required]],
    address: ['', [Validators.required]],
    dob: ['', [Validators.required]],
    gender: ['', [Validators.required]]
  });
 
  saveForm(){
    console.log('Form data is ', this.profileForm.value);
  }

}
