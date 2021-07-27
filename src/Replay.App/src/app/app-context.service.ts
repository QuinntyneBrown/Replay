import { Injectable } from '@angular/core';
import { ToDoService } from '@api/services';
import { BehaviorSubject } from 'rxjs';
import { shareReplay, switchMap } from 'rxjs/operators';

@Injectable()
export class AppContextService {

  private _refresh$ = new BehaviorSubject<void>(null);

  public toDos$ = this._refresh$
  .pipe(
    switchMap(_ => this._toDoService.get()),
    shareReplay(1)
  );

  constructor(
    private readonly _toDoService: ToDoService
  ) {

  }

  public refresh() {
    this._refresh$.next();
  }
}
