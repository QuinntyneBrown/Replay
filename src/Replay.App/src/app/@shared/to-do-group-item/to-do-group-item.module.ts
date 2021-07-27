import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToDoGroupItemComponent } from './to-do-group-item.component';
import { MatIconModule } from '@angular/material/icon';


@NgModule({
  declarations: [
    ToDoGroupItemComponent
  ],
  exports: [
    ToDoGroupItemComponent
  ],
  imports: [
    CommonModule,
    MatIconModule
  ]
})
export class ToDoGroupItemModule { }
