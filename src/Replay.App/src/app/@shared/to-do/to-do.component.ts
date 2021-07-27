import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToDoService } from '@api';
import { Subject } from 'rxjs';
import { takeUntil, tap } from 'rxjs/operators';

@Component({
  selector: 'app-to-do',
  templateUrl: './to-do.component.html',
  styleUrls: ['./to-do.component.scss']
})
export class ToDoComponent  {

  private readonly _destroyed$ = new Subject();

  public form: FormGroup = new FormGroup({
    type: new FormControl(null, []),
    name: new FormControl(null,[]),
    description: new FormControl(null,[])
  })

  constructor(
    private readonly _toDoService: ToDoService,
    private readonly _dialogRef: MatDialogRef<ToDoComponent>,
    @Inject(MAT_DIALOG_DATA) type:string
  ) {
    this.form.patchValue({
      type
    });
  }
  public handleSaveClick() {
    this._toDoService.create({ toDo: this.form.value })
    .pipe(
      takeUntil(this._destroyed$),
      tap(_ => this._dialogRef.close())
    )
    .subscribe();
  }
}
