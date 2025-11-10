import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CourseService } from '../../../services/course';

@Component({
  selector: 'app-course-details',
  templateUrl: './course-details.html',
  styleUrl: './course-details.css',
  standalone: false
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
