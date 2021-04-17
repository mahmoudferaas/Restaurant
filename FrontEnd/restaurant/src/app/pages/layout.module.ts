import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InlineSVGModule } from 'ng-inline-svg';
import { PagesRoutingModule } from './pages-routing.module';
import {
  NgbDropdownModule,
  NgbProgressbarModule,
} from '@ng-bootstrap/ng-bootstrap';
import { TranslationModule } from '../core/i18n/translation.module';
import { LayoutComponent } from './_layout/layout.component';
import { ScriptsInitComponent } from './_layout/init/scipts-init/scripts-init.component';
import { HeaderMobileComponent } from './_layout/components/header-mobile/header-mobile.component';
import { FooterComponent } from './_layout/components/footer/footer.component';
import { HeaderComponent } from './_layout/components/header/header.component';
import { TopbarComponent } from './_layout/components/topbar/topbar.component';
import { ExtrasModule } from '../partials/layout/extras/extras.module';
import { LanguageSelectorComponent } from './_layout/components/topbar/language-selector/language-selector.component';
import { CoreModule } from '../core';
import { SubheaderModule } from '../partials/layout/subheader/subheader.module';
import {AsideComponent} from './_layout/components/aside/aside.component';
import {HeaderMenuComponent} from './_layout/components/header/header-menu/header-menu.component';
import {ListComponent} from '../partials/list/list.component';
import {ConfirmationDialogComponent} from '../partials/confirmation-dialog/confirmation-dialog.component';
import {MatDialogModule} from "@angular/material/dialog";
import {MatButtonModule} from "@angular/material/button";

@NgModule({
  declarations: [
    LayoutComponent,
    ScriptsInitComponent,
    HeaderMobileComponent,
    FooterComponent,
    HeaderComponent,
    TopbarComponent,
    LanguageSelectorComponent,
    AsideComponent,
    HeaderMenuComponent,
    ListComponent,
    ConfirmationDialogComponent
  ],
    imports: [
        CommonModule,
        PagesRoutingModule,
        TranslationModule,
        InlineSVGModule,
        ExtrasModule,
        NgbDropdownModule,
        NgbProgressbarModule,
        CoreModule,
        SubheaderModule,
        MatDialogModule,
        MatButtonModule,
    ],
  exports: [
    ListComponent
  ],
  entryComponents: [ConfirmationDialogComponent]
})
export class LayoutModule { }
