import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplayTechnologiesComponent } from './display-technologies.component';

describe('DisplayTechnologiesComponent', () => {
  let component: DisplayTechnologiesComponent;
  let fixture: ComponentFixture<DisplayTechnologiesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DisplayTechnologiesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DisplayTechnologiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
