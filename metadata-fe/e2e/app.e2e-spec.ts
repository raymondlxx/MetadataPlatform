import { MetadataWebPage } from './app.po';

describe('metadata-web App', () => {
  let page: MetadataWebPage;

  beforeEach(() => {
    page = new MetadataWebPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
