import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ModuleService } from '../../services/module';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-module-create',
  imports: [FormsModule, CommonModule], 
  templateUrl: './module-create.html',
  styleUrls: ['./module-create.css']
})
export class ModuleCreate implements OnInit {
  courseId!:number;

  model = {
    title:'',
    courseId: 0 
  };

  constructor(private route:ActivatedRoute,
    private moduleService: ModuleService
  ){}

  ngOnInit(): void {
    this.courseId= Number(this.route.snapshot.paramMap.get('courseId'));
    this.model.courseId = this.courseId;
  }

  createModule(){
    this.moduleService.create(this.model).subscribe(()=>{
      alert('Module created!')
    });
  }

}
