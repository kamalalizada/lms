import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LessonService } from '../../services/lesson';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-lesson-create',
  imports: [FormsModule, CommonModule], 
  templateUrl: './lesson-create.html',
  styleUrl: './lesson-create.css'
})
export class LessonCreate implements OnInit {
  courseId!:number;
  moduleId!:number;

  model={
    title:'',
    content:'',
    moduleId:0
  };

  constructor(private route:ActivatedRoute,
    private lessonService:LessonService
  ){}

  ngOnInit(): void {
    this.courseId=Number(this.route.snapshot.paramMap.get('courseId'));
    this.moduleId=Number(this.route.snapshot.paramMap.get('moduleId'));
    this.model.moduleId = this.moduleId;
  }

  createLesson(){
    this.lessonService.create(this.model).subscribe(()=>{
      alert("Lesson created succesfully!");
    });
  }

}
