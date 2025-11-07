import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CourseService } from '../../services/course';
import { BrowserModule } from "@angular/platform-browser";

@Component({
  selector: 'app-lesson-view',
  imports: [BrowserModule],
  templateUrl: './lesson-view.html',
  styleUrl: './lesson-view.css'
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
