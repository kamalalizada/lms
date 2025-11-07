import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModuleCreate } from './module-create';

describe('ModuleCreate', () => {
  let component: ModuleCreate;
  let fixture: ComponentFixture<ModuleCreate>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ModuleCreate]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ModuleCreate);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
