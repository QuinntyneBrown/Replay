import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToDoGroupComponent } from './to-do-group.component';
import { ToDoGroupItemModule } from '@shared/to-do-group-item';
import { MatDialogModule } from '@angular/material/dialog';
import { ToDoModule } from '@shared/to-do/to-do.module';


@NgModule({
  declarations: [
    ToDoGroupComponent
  ],
  exports: [
    ToDoGroupComponent
  ],
  imports: [
    CommonModule,
    ToDoGroupItemModule,
    MatDialogModule,
    ToDoModule
  ]
})
export class ToDoGroupModule { }
