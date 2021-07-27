import { Component, Input, OnInit } from '@angular/core';
import { ToDo } from '@api';
import { ToDoStatus } from '@api/models/to-do-status';
import { ToDoItemType } from '@shared/to-do-item-type';

@Component({
  selector: 'app-to-do-group-item',
  templateUrl: './to-do-group-item.component.html',
  styleUrls: ['./to-do-group-item.component.scss']
})
export class ToDoGroupItemComponent {

  public ToDoItemType: typeof ToDoItemType = ToDoItemType;

  @Input() public type: ToDoItemType = ToDoItemType.ToDo;

  @Input() public toDo: ToDo;

  public get title() {
    return this.type == ToDoItemType.ToDo ? this.toDo.name : "Add To Do";
  }

  public get icon() {

    if(this.type == ToDoItemType.AddAction) {
      return "add";
    }

    if(this.toDo.status == ToDoStatus.Defualt || this.toDo.status == ToDoStatus.Deferred) {
      return "radio_button_unchecked";
    }

    return "radio_button_checked";
  }
}
