import { AdTypeEnum } from './Enums/AdTypeEnum';
import { UserTypeEnum } from './Enums/UserTypeEnum';
import { Calculator } from './calculator';
import moment from 'moment';

const testCases = [
    {
        userType: UserTypeEnum.Normal,
        adType: AdTypeEnum.Auction,
        price: 10,
        endDate: moment().format("YYYY-MM-DD"),
        expected: 25
    },
    {
        userType: UserTypeEnum.Normal,
        adType: AdTypeEnum.Auction,
        price: 10,
        endDate: moment().subtract(1, "days").format("YYYY-MM-DD"),
        expected: 35
    },
    {
        userType: UserTypeEnum.Normal,
        adType: AdTypeEnum.BuyItNow,
        price: 10,
        endDate: moment().format("YYYY-MM-DD"),
        expected: 35
    },
    {
        userType: UserTypeEnum.Normal,
        adType: AdTypeEnum.BuyItNow,
        price: 10,
        endDate: moment().subtract(1, "days").format("YYYY-MM-DD"),
        expected: 45
    },
    {
        userType: UserTypeEnum.Company,
        adType: AdTypeEnum.Auction,
        price: 10,
        endDate: moment().format("YYYY-MM-DD"),
        expected: 20
    },
    {
        userType: UserTypeEnum.Company,
        adType: AdTypeEnum.Auction,
        price: 10,
        endDate: moment().subtract(1, "days").format("YYYY-MM-DD"),
        expected: 30
    },
    {
        userType: UserTypeEnum.Company,
        adType: AdTypeEnum.BuyItNow,
        price: 10,
        endDate: moment().format("YYYY-MM-DD"),
        expected: 25
    },
    {
        userType: UserTypeEnum.Company,
        adType: AdTypeEnum.BuyItNow,
        price: 10,
        endDate: moment().subtract(1, "days").format("YYYY-MM-DD"),
        expected: 35
    },
];
describe("Calculator", () => {
    test.each(testCases)("Can calculate fee", (testCase) => {
        const calc = new Calculator();
        const fee = calc.getFee(testCase);
        expect(fee).toBe(testCase.expected);
    });
});