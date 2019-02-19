import { TestBed } from '@angular/core/testing';

import { ListRelacoesService } from './list-relacoes.service';

describe('ListRelacoesService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ListRelacoesService = TestBed.get(ListRelacoesService);
    expect(service).toBeTruthy();
  });
});
