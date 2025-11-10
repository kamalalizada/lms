import { Component, NgModule, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CourseService } from '../../../services/course';

@Component({
  selector: 'app-lesson-view',
  standalone: false,
  templateUrl: './lesson-view.html',
  styleUrls: ['./lesson-view.css']
})
export class LessonView implements OnInit {
  course: any;
  selectedLesson:any = null;

  constructor(private route:ActivatedRoute,private courseService:CourseService){}

  ngOnInit(): void {
    const courseId=Number(this.route.snapshot.paramMap.get('id'));
    this.courseService.getById(courseId).subscribe(res=>{
    this.course = res;
  });
  }

  openLesson(lesson:any){
    this.selectedLesson = lesson;
  }

  
}
