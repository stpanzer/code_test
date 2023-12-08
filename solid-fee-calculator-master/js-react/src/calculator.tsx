import moment from 'moment';
import { UserTypeEnum } from './Enums/UserTypeEnum';
import { AdTypeEnum } from './Enums/AdTypeEnum';

export class Calculator {
  getFee({userType, adType: itemType, price, endDate}: {userType: UserTypeEnum, adType: AdTypeEnum, price: number, endDate: string}) {    
    return price + this.itemPrices[itemType] - this.calculateDiscount(userType, endDate);
  }

  private itemPrices = {
    [AdTypeEnum.Auction]: 25,
    [AdTypeEnum.BuyItNow]: 35
  };

  private calculateDiscount(userType: UserTypeEnum, endDate: string) {
    let discount = 0;
    if(moment(endDate).isSame(moment(), 'day')) {
      discount += 10;
    }
    if(userType === UserTypeEnum.Company) {
      discount += 5;
    }
    return discount;

  }
}
