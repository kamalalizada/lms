import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CourseService } from '../../services/course';
import { BrowserModule } from "@angular/platform-browser";

@Component({
  selector: 'app-course-details',
  imports: [BrowserModule],
  templateUrl: './course-details.html',
  styleUrl: './course-details.css'
})
export class CourseDetails implements OnInit {
  course:any;
  courseId!:number;
  loading=true;

  constructor(
    private route:ActivatedRoute,
    private courseService:CourseService
  ){}

  ngOnInit(): void{
    this.courseId = Number(this.route.snapshot.paramMap.get('id'));

  this.courseService.getById(this.courseId).subscribe(res=>{
    this.course=res;
    this.loading=false;
  });
}

enroll(){
  const studentId=1;

  this.courseService.enroll(this.courseId,studentId).subscribe(()=>{
    alert("Enrolled!");
  })
}

}
