import { Component, OnInit } from '@angular/core';
import { CourseService } from '../../../services/course';

@Component({
  selector: 'app-instructor-course-list',
  templateUrl: './course-list.html',
  styleUrl: './course-list.css',
  standalone: false
})
export class CourseList implements OnInit {
  courses:any[]=[];
  instructorId = 1;

  constructor(private courseService:CourseService){}

  ngOnInit(): void {
    this.courseService.getByInstructorId(this.instructorId).subscribe(res=>{
      this.courses=res;
    }); 
  }
}
