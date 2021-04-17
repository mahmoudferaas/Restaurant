import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ItemService } from 'src/app/core/services/item.service';
import { ReservationService } from 'src/app/core/services/reservation.service';

@Component({
  selector: 'app-create-reservation',
  templateUrl: './create-reservation.component.html',
  styleUrls: ['./create-reservation.component.scss']
})
export class CreateReservationComponent implements OnInit {

  reservationForm: FormGroup;
  items: any = [];
  selectedItems: any = [];
  menuSelections : any = [];

  constructor(private formBuilder: FormBuilder,
    private reservationService : ReservationService,
    private itemService : ItemService) { }
    dropdownSettings: any = {};

  ngOnInit(): void {

    this.items = this.itemService.getItems();
    this.dropdownSettings = {
                singleSelection: false,
                idField: 'id',
                textField: 'name',
                selectAllText: 'Select All',
                unSelectAllText: 'UnSelect All',
                itemsShowLimit: 3,
                allowSearchFilter: false
            };

    this.reservationForm = this.formBuilder.group({
      numberOfGuests: [null, [Validators.required]],
      reservationDate: [null, [Validators.required]],
      specialRequests: [null, [Validators.required]],
      userId: [null],
      menuSelections : [this.menuSelections]
  });
  }

  onItemSelect(item: any) {
    this.menuSelections.push(item.id);
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
