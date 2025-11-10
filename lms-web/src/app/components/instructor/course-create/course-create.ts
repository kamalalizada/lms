import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CourseService } from '../../../services/course';

@Component({
  selector: 'app-course-create',
  templateUrl: './course-create.html',
  styleUrl: './course-create.css',
  standalone: false
})
export class CourseCreate  {
  model={
    title:'',
    description:'',
    instructorId:1
  };

  constructor(private courseService:CourseService){}

  createCourse(){
    this.courseService.create(this.model).subscribe(()=>{
      alert("Courseated!");
    });
  }

}
