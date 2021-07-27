import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToDoGroupItemComponent } from './to-do-group-item.component';

describe('ToDoGroupItemComponent', () => {
  let component: ToDoGroupItemComponent;
  let fixture: ComponentFixture<ToDoGroupItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToDoGroupItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToDoGroupItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
