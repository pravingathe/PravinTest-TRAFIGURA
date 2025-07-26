import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PositionsReport } from './positions-report';

describe('PositionsReport', () => {
  let component: PositionsReport;
  let fixture: ComponentFixture<PositionsReport>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PositionsReport]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PositionsReport);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
