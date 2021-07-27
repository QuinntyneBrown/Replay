import { Component } from '@angular/core';
import { AppContextService } from '../app-context.service';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent  {
  public readonly types = ["Work", "Personal"];

  constructor(
    private readonly _appContextService: AppContextService
  ) { }

  public handleToDosChange():void {
    this._appContextService.refresh();
  }
}
