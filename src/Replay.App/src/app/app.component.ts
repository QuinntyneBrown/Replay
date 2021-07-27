import { Component } from '@angular/core';
import { AppContextService } from './app-context.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  providers: [
    AppContextService
  ]
})
export class AppComponent {

}
