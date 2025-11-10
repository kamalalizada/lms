import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LessonService } from '../../../services/lesson';

@Component({
  selector: 'app-lesson-create',
  templateUrl: './lesson-create.html',
  styleUrl: './lesson-create.css',
  standalone: false
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
