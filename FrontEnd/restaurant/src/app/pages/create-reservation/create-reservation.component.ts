import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReservationService } from 'src/app/core/services/reservation.service';

@Component({
  selector: 'app-create-reservation',
  templateUrl: './create-reservation.component.html',
  styleUrls: ['./create-reservation.component.scss']
})
export class CreateReservationComponent implements OnInit {
  reservationForm: FormGroup;
  constructor(private formBuilder: FormBuilder,
    private reservationService : ReservationService) { }

  ngOnInit(): void {
    this.reservationForm = this.formBuilder.group({
      numberOfGuests: [null, [Validators.required]],
      reservationDate: [null, [Validators.required]],
      specialRequests: [null, [Validators.required]],
      userId: [null]
  });
  }


  submit() {
    this.reservationForm.controls['userId'].setValue(localStorage.getItem('userId'));
    // this.authService.register(this.registarForm.value).subscribe((data : any)=>{
    //     localStorage.setItem('token',data.token);
    //     this.router.navigate(['/home']);
    //   },
    //   (err : HttpErrorResponse)=>{
    //     this.loading = true;
    //   });
    }

}
