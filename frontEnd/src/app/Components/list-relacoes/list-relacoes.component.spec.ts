import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListRelacoesComponent } from './list-relacoes.component';

describe('ListRelacoesComponent', () => {
  let component: ListRelacoesComponent;
  let fixture: ComponentFixture<ListRelacoesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListRelacoesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListRelacoesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
