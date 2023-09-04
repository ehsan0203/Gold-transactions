import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GemsComponent } from './gems.component';

describe('GemsComponent', () => {
  let component: GemsComponent;
  let fixture: ComponentFixture<GemsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GemsComponent]
    });
    fixture = TestBed.createComponent(GemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
