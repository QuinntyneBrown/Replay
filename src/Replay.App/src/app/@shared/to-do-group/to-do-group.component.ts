import { Component, EventEmitter, Input, OnDestroy, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ToDo, ToDoService } from '@api';
import { ToDoItemType } from '@shared/to-do-item-type';
import { ToDoComponent } from '@shared/to-do/to-do.component';
import { Subject } from 'rxjs';
import { map, takeUntil, tap } from 'rxjs/operators';
import { AppContextService } from 'src/app/app-context.service';

@Component({
  selector: 'app-to-do-group',
  templateUrl: './to-do-group.component.html',
  styleUrls: ['./to-do-group.component.scss']
})
export class ToDoGroupComponent implements OnDestroy {

  private readonly _destroyed$ = new Subject();

  public readonly ToDoItemType: typeof ToDoItemType = ToDoItemType;

  @Input() public type!:string;

  @Output() public toDosChange: EventEmitter<void> = new EventEmitter();

  public readonly vm$ = this._appContextService.toDos$
  .pipe(
    map(toDos => toDos.filter(toDo => toDo.type == this.type)),
    map(toDos => ({ toDos }))
  );

  constructor(
    private readonly _appContextService: AppContextService,
    private readonly _toDoService: ToDoService,
    private readonly _dialog: MatDialog
  ) { }

  public handleAddAction(type:string) {
    this._dialog.open<ToDoComponent>(ToDoComponent, {
      data:type
    })
    .afterClosed()
    .pipe(
      tap(_ => this.toDosChange.emit())
    )
    .subscribe();
  }

  public handleToDoClick(toDo: ToDo) {
    this._toDoService.complete({ toDo })
    .pipe(
      takeUntil(this._destroyed$),
      tap(x => this._appContextService.refresh())

    ).subscribe();
  }

  ngOnDestroy() {
    this._destroyed$.next();
    this._destroyed$.complete();
  }
}
